
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
            view.ShowHeader("Estoque");

            var entries = estoque.ReadEntries();
            if(entries.Count == 0) {
                Console.WriteLine("Nenhuma carta no estoque.");
                view.Pause();
                return;
            }

            int i = 1;
            foreach(var kv in entries) {
                Console.WriteLine($"{i} - {kv.Value}");
                i++;
            }

            view.Pause();
        }

        private void BuyFlow() {
            view.ShowHeader("Comprar Carta");

            var entries = estoque.ReadEntries();
            if(entries.Count == 0) {
                Console.WriteLine("Nenhuma carta disponível para compra.");
                view.Pause();
                return;
            }

            var keys = new List<string>(entries.Keys);
            for(int idx = 0; idx < keys.Count; idx++) {
                var data = entries[keys[idx]];
                Console.WriteLine($"{idx+1} - {data}");
            }

            int sel = view.AskForSelection(keys.Count);
            if(sel <= 0) {
                Console.WriteLine("Compra cancelada.");
                view.Pause();
                return;
            }

            string key = keys[sel-1];
            string value = entries[key];

            int qty = 1;
            Console.Write("Quantidade a comprar: ");
            try { qty = Math.Max(1, Convert.ToInt32(Console.ReadLine())); } catch { qty = 1; }

            bool okCreate = compradas.Create(Guid.NewGuid().ToString(), value);
            bool okDelete = estoque.Delete(key);

            if(okCreate && okDelete) {
                Console.WriteLine("Compra efetuada com sucesso.");
            } else {
                Console.WriteLine("Falha ao registrar a compra.");
            }

            view.Pause();
        }

        private void ShowCompradas() {
            view.ShowHeader("Cartas Compradas");

            var list = compradas.Read();
            if(list.Length == 0) {
                Console.WriteLine("Nenhuma carta comprada nesta sessão.");
                view.Pause();
                return;
            }

            for(int i = 0; i < list.Length; i++) {
                Console.WriteLine($"{i+1} - {list[i]}");
            }

            view.Pause();
        }
    }
}