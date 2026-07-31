
using System.Text.Json;

namespace Magic {
    class VendedorController : IController {

        private VendedorView view = new VendedorView();
        private Estoque estoque = new Estoque();
        private CartaBase cartaBase = new CartaBase();
    
        public void Run() {
            VendedorView.MenuOpcoes opcao;

            do
            {
                opcao = view.Menu();

                switch (opcao)
                {
                    default: break;
                    case VendedorView.MenuOpcoes.VENDA:
                        AdicionarCarta();
                        break;

                    case VendedorView.MenuOpcoes.LISTAR:
                        ListarCartas();
                        break;

                    case VendedorView.MenuOpcoes.REMOVER:
                        RemoverCarta();
                        break;

                    case VendedorView.MenuOpcoes.EDITAR:
                        EditarCarta();
                        break;
                }

            } while (opcao != VendedorView.MenuOpcoes.VOLTAR);
        }

        private void AdicionarCarta()
        {
            // Pergunta o nome da carta
            string nome = view.LerNomeCarta();

            // Procura carta no banco de dados
            string? cartaJson = cartaBase.Read(nome);

            if (string.IsNullOrWhiteSpace(cartaJson))
            {
                view.MostrarMensagem("Essa carta nao existe no sistema!");
                view.Pause();
                return;
            }

            // Pergunta o preço da carta
            float preco = view.LerPreco();

            // Coloca a carta a venda

            Carta carta = JsonSerializer.Deserialize<Carta>(cartaJson) ?? new Carta();

            carta.Nome = nome;
            carta.Preco = preco;
            
            //Cria um ID para a carta a venda
            carta.GID = Guid.NewGuid().ToString();

            string json = JsonSerializer.Serialize<Carta>(carta);

            estoque.Create(carta.GID, json);
            view.Pause();
        }

        private void ListarCartas()
        {
            string[] cartas = estoque.Read();

            view.MostrarLista(cartas);
            view.Pause();
        }

        private void RemoverCarta()
        {
            string id = view.LerIdCarta();

            bool removido = estoque.Delete(id);

            if (removido)
                view.MostrarMensagem("Carta removida do mercado!");
            else
                view.MostrarMensagem("Carta nao encontrada!");
            view.Pause();
        }

        private void EditarCarta() {
            string id = view.LerIdCarta();
            string? cartaJSON = estoque.Read(id);

            if(cartaJSON == null) {
                view.MostrarMensagem("Carta nao encontrada!");
                view.Pause();
                return;
            }

            Carta? carta = JsonSerializer.Deserialize<Carta>(cartaJSON);
            if(carta == null) return;

            float preco = view.LerNovoPreco(carta.Preco ?? 0);
            carta.Preco = preco;

            if(estoque.Update(id, JsonSerializer.Serialize<Carta>(carta)))
                view.MostrarMensagem("Carta atualizada com sucesso!");
            else
                view.MostrarMensagem("Houve um erro na atualizacao da carta.");
            view.Pause();
        }
    }
}