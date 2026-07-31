using System.Text.Json;

namespace Magic {
    class AdministradorController : IController {
        private CartaBase CardDatabase = new CartaBase();
        private AdmView view = new AdmView();

        public void Run() {
            AdmView.OperationOptions option = AdmView.OperationOptions.NULL;
            do {
                option = view.GetOperationOption();

                switch(option) {
                    default:
                        break;
                    case AdmView.OperationOptions.CREATE:
                        CreateCard();
                        break;
                    case AdmView.OperationOptions.SEARCH:
                        GetCard();
                        break;
                    case AdmView.OperationOptions.LIST:
                        ListCards();
                        break;
                    case AdmView.OperationOptions.UPDATE:
                        UpdateCard();
                        break;
                    case AdmView.OperationOptions.DELETE:
                        DeleteCard();
                        break;
                }
            } while (option != AdmView.OperationOptions.EXIT);
        }

        public void CreateCard(){
            Carta c = view.GetCardValues();
            CardDatabase.Create(c.Nome!, JsonSerializer.Serialize<Carta>(c));
            view.Pause();
        }

        public void GetCard() {
            string? nome_carta = view.GetCardName();
            if(String.IsNullOrWhiteSpace(nome_carta)) return;

            string? carta_s = CardDatabase.Read(nome_carta);
            if(String.IsNullOrWhiteSpace(carta_s)) {
                view.MostrarMensagem("Nao existe um carta com esse nome! (Essa busca é sensitiva a capitalização)");
                view.Pause();
                return;
            }

            Carta carta = JsonSerializer.Deserialize<Carta>(carta_s) ?? new Carta();
            view.MostrarCarta(carta);
            view.Pause();
        }

        public void ListCards(){
            string[] cartas = CardDatabase.Read();
            if(cartas.Length <= 0) {
                view.MostrarMensagem("Nao tem nenhuma carta registrada no sistema!");
                view.Pause();
                return;
            }

            foreach(string carta_s in cartas) {
                Carta? carta = JsonSerializer.Deserialize<Carta>(carta_s);
                if(carta == null) continue;

                view.MostrarCarta(carta);
            }
            view.Pause();
        }

        public void UpdateCard(){
            Carta c = view.GetCardValues();
            CardDatabase.Update(c.Nome!, JsonSerializer.Serialize<Carta>(c));
            view.Pause();
        }

        public void DeleteCard(){
            string? nome = view.GetCardName();
            if(String.IsNullOrWhiteSpace(nome)) return;

            if(!CardDatabase.Delete(nome)) {
                view.MostrarMensagem("Houve um erro deletando essa carta.");
            } else {
                view.MostrarMensagem("Carta deletada com sucesso.");
            }
            view.Pause();
        }
    }
}