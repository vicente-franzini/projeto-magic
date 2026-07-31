using System.Text.Json;

namespace Magic {

    class VendedorView
    {

        public enum MenuOpcoes {
            VOLTAR, VENDA, LISTAR, REMOVER, EDITAR
        };
        public MenuOpcoes Menu()
        {
            MostrarCabecalho("Vendedor");
            Console.WriteLine(" 1 - Colocar carta à venda");
            Console.WriteLine(" 2 - Listar minhas cartas");
            Console.WriteLine(" 3 - Remover carta");
            Console.WriteLine(" 0 - Sair\n");

            Console.Write("> ");

            return (MenuOpcoes) Convert.ToInt32(Console.ReadLine());
        }

        public string LerNomeCarta()
        {
            Console.Write("Nome da carta: ");
            return Console.ReadLine()!;
        }

        public float LerPreco()
        {
            Console.Write("Preço: ");
            return Convert.ToSingle(Console.ReadLine());
        }

        public float LerNovoPreco(float precoAtual)
        {
            Console.Write($"Preco atual {precoAtual}\nPreco novo: ");
            return Convert.ToSingle(Console.ReadLine());
        }

        public string LerIdCarta()
        {
            Console.Write("Id da carta: ");
            return Console.ReadLine()!;
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public void MostrarCabecalho(string title) {
			Console.Clear();
			Console.WriteLine("=== " + title + " ===\n");
		}

        public void MostrarCarta(Carta carta) {
            Console.WriteLine(
                $"{carta.Nome}" + (!String.IsNullOrWhiteSpace(carta.GID) ? $" ({carta.GID})\n" : "\n") +
                $"{Enum.GetName<Carta.Cores>(carta.Cor)} - {carta.ValorMana} {carta.CustoMana}\n" +
                $"{carta.Tipo}\n" + 
                $"{carta.Descricao}" + (carta.Poder != null ? $"({carta.Poder}/{carta.Resistencia})\n" : "\n") +
                (carta.Preco != null && carta.Preco != 0 ? $"Preco: ${carta.Preco}\n" : "\n")
            );
        }

        public void MostrarLista(string[] cartas)
        {
            MostrarCabecalho("Cartas anunciadas");
            if(cartas.Length <= 0) Console.WriteLine("Nao tem cartas a venda!");

            foreach(string carta_s in cartas) {
                Carta? carta = JsonSerializer.Deserialize<Carta>(carta_s);
                if(carta == null) continue;

                MostrarCarta(carta);
            }
        }

        public void Pause() {
			Console.WriteLine("\nPressione Enter para continuar...");
			Console.ReadLine();
		}
    }

}