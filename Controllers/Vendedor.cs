
using System.Text.Json;

namespace Magic {
    class VendedorController : IController {

        private VendedorView view = new VendedorView();
        private Estoque estoque = new Estoque();
        private CartaBase cartaBase = new CartaBase();
    
        public void Run() {
            int opcao;

            do
            {
                opcao = view.Menu();

                switch (opcao)
                {
                    case 1:
                        AdicionarCarta();
                        break;

                    case 2:
                        ListarCartas();
                        break;

                    case 3:
                        RemoverCarta();
                        break;
                }

            } while (opcao != 0);
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
                return;
            }

            // Pergunta o preço da carta
            float preco = view.LerPreco();

            // Coloca a carta a venda

            Carta carta = new Carta();

            carta.Nome = nome;
            carta.Preco = preco;
            
            //Cria um ID para a carta a venda
            string id = Guid.NewGuid().ToString();
            string json = JsonSerializer.Serialize(carta);

            estoque.Create(id, json);
        }

        private void ListarCartas()
        {
            string[] cartas = estoque.Read();

            view.MostrarLista(cartas);
        }

        private void RemoverCarta()
        {
            string id = view.LerIdCarta();

            bool removido = estoque.Delete(id);

            if (removido)
                view.MostrarMensagem("Carta removida do mercado!");
            else
                view.MostrarMensagem("Carta nao encontrada!");
        }
    }
}