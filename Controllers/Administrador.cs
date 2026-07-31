using System.Text.Json;

namespace Magic {
    class AdministradorController : IController {
        private CartaBase CardDatabase = new CartaBase();
        private AdmView view = new AdmView();

        public void Run() {
            do{
                AdmView.OperationOptions option = view.GetOperationOption();

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
            }while(option != AdmView.OperationOptions.EXIT);
        }

        public void CreateCard(){
            Carta c = view.GetCardValues();
            CardDatabase.Create(c.OutputValuesString());
        }

        public void GetCard(){
            view.PrintCard(CardDatabase.Read(view.GetCardName()));
        }

        public void ListCards(){
            Carta[] cartas = CardDatabase.Read();
            foreach(Carta c in cartas){
                view.PrintCard(c);
            }
        }

        public void UpdateCard(){
            Carta c = view.GetCardValues();
            CardDatabase.Update(c.OutputValuesString());
        }

        public void DeleteCard(){
            CardDatabase.Delete(view.GetCardName());
        }
    }
}