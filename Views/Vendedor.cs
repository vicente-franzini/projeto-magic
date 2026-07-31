using System.Text.Json;

namespace Magic {

    class VendedorView
    {

        public enum MenuOpcoes {
            VOLTAR, VENDA, LISTAR, REMOVER, EDITAR
        };
        public MenuOpcoes Menu()
        {
            MostrarCabecalho("Menu do Vendedor");
            Console.WriteLine("1 - Colocar carta à venda");
            Console.WriteLine("2 - Listar minhas cartas");
            Console.WriteLine("3 - Remover carta");
            Console.WriteLine("0 - Voltar");

            Console.Write("Opção: ");

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

        public void MostrarLista(string[] cartas)
        {
            MostrarCabecalho("Cartas anunciadas");

            foreach(string carta_s in cartas) {
                Carta? carta = JsonSerializer.Deserialize<Carta>(carta_s);
                if(carta == null) continue;

                if(carta.Poder != null && carta.Resistencia != null)
                    Console.WriteLine(
                        $"{carta.Nome} ({carta.GID})\n" +
                        $"{Enum.GetName<Carta.Cores>(carta.Cor)} - {carta.ValorMana} {carta.CustoMana}\n" +
                        $"{carta.Tipo}" + 
                        $"{carta.Descricao} -- ({carta.Poder}/{carta.Resistencia})\n" +
                        $"Preco: ${carta.Preco}\n\n"
                    );
                else
                    Console.WriteLine(
                        $"{carta.Nome} ({carta.GID})\n" +
                        $"{Enum.GetName<Carta.Cores>(carta.Cor)} - {carta.ValorMana} {carta.CustoMana}\n" +
                        $"{carta.Tipo}" + 
                        $"{carta.Descricao}\n" +
                        $"Preco: ${carta.Preco}\n\n"
                    );
            }
        }
    }

}