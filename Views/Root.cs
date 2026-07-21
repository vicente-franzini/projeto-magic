
namespace Magic {

    class RootView {
        public enum UserOptions {
            NULL, ADMINISTRADOR, VENDEDOR, COMPRADOR
        };

        public UserOptions GetUserAccount() {
            UserOptions finalOption = UserOptions.NULL;

            while(finalOption < UserOptions.ADMINISTRADOR || finalOption > UserOptions.COMPRADOR) {
                Console.Write(
                    "[Escolha a sua conta]\n" +
                    " 1 - Administrador (modifique as cartas do sistema)\n" +
                    " 2 - Vendedor (coloque cartas a venda)\n" +
                    " 3 - Comprador (compre cartas que estão a venda)\n\n" +
                    "> "
                );

                try { finalOption = (UserOptions) Convert.ToUInt32(Console.ReadLine()); }
                catch (Exception e) {
                    if(e is FormatException) {
                        Console.WriteLine("Digite um número!");
                    }
                }

                if(finalOption < UserOptions.ADMINISTRADOR || finalOption > UserOptions.COMPRADOR) {
                    Console.WriteLine("Opção inválida!");
                }
            }

            return finalOption;
        }
    }
}