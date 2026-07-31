

namespace Magic {
    class RootController : IController {

        private RootView view = new RootView();

        public void Run() {
            RootView.UserOptions option = view.GetUserAccount();

            switch(option) {
                default:
                    view.MostrarMensagem("Houve algum erro na seleção de usuários! Reiniciando.");
                    Run();
                    break;
                case RootView.UserOptions.ADMINISTRADOR:
                    new AdministradorController().Run();
                    break;
                case RootView.UserOptions.COMPRADOR:
                    new CompradorController().Run();
                    break;
                case RootView.UserOptions.VENDEDOR:
                    new VendedorController().Run();
                    break;
            }
        }
    }
}