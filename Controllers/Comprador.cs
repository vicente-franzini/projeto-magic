using System.Text.Json;

namespace Magic {
    class CompradorController : IController {
        private Estoque estoque = new Estoque();
        private Compradas compradas = new Compradas();
        private CompradorView view = new CompradorView();

        public void Run() {
            while(true) {
                var opt = view.MainMenu();
                switch(opt) {
                    case CompradorView.MenuOptions.VER_ESTOQUE:
                        ShowEstoque();
                        break;
                    case CompradorView.MenuOptions.COMPRAR:
                        BuyFlow();
                        break;
                    case CompradorView.MenuOptions.VER_COMPRADAS:
                        ShowCompradas();
                        break;
                    case CompradorView.MenuOptions.SAIR:
                        return;
                    default:
                        break;
                }
            }
        }

        private void ShowEstoque() {
            view.MostrarCabecalho("Estoque");

            var entries = estoque.Read();
            if(entries.Length == 0) {
                Console.WriteLine("Nenhuma carta no estoque.");
                view.Pause();
                return;
            }

            view.MostrarLista(entries);
            view.Pause();
        }

        private void BuyFlow() {
            view.MostrarCabecalho("Comprar carta");

            var entries = estoque.Read();
            if(entries.Length != 0) view.MostrarLista(entries);

            view.MostrarMensagem(
                "Digite abaixo o ID da carta. Voce pode obter ele listando o estoque.\n" +
                "Para voltar, aperte enter."
            );

            string id = view.LerIdCarta();
            if(String.IsNullOrWhiteSpace(id)) return;

            string? carta_s = estoque.Read(id);
            if(String.IsNullOrWhiteSpace(carta_s)) {
                view.MostrarMensagem("Nao existe uma carta com esse id!");
                view.Pause();
                return;
            }

            Carta? carta = JsonSerializer.Deserialize<Carta>(carta_s);
            if(carta == null) return;

            view.MostrarCarta(carta);
            bool comprada = view.ComprarCarta();

            if(comprada) {
                if(
                    compradas.Create(id, carta_s) &&
                    estoque.Delete(id)
                ) view.MostrarMensagem("A carta foi adquirida!");
                else view.MostrarMensagem("Houve um erro na compra da carta.");
            } else {
                view.MostrarMensagem("Voce optou por nao comprar a carta.");
            }

            view.Pause();
        }

        private void ShowCompradas() {
            view.MostrarCabecalho("Cartas Compradas");

            var list = compradas.Read();
            if(list.Length == 0) {
                Console.WriteLine("Nenhuma carta comprada.");
                view.Pause();
                return;
            }

            view.MostrarLista(list, true);
            view.Pause();
        }
    }
}