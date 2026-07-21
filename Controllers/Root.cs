

namespace Magic {
    class RootController : IController {
        public void Run() {
            RootView view = new RootView();
            RootView.UserOptions option = view.GetUserAccount();

            switch(option) {
                default:
                    Console.WriteLine("Houve algum erro na seleção de usuários! Reiniciando.");
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