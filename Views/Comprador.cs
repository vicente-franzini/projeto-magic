
using System.Text.Json;

namespace Magic {
	class CompradorView {
		public enum MenuOptions { NULL, VER_ESTOQUE, COMPRAR, VER_COMPRADAS, SAIR }

		public void MostrarCabecalho(string title) {
			Console.Clear();
			Console.WriteLine("=== " + title + " ===\n");
		}

		public MenuOptions MainMenu() {
			MostrarCabecalho("Comprador");

			Console.WriteLine(" 1 - Ver todas as cartas disponíveis");
			Console.WriteLine(" 2 - Comprar uma carta");
			Console.WriteLine(" 3 - Ver cartas compradas");
			Console.WriteLine(" 4 - Sair\n");
			Console.Write("> ");

			try {
				var v = Convert.ToInt32(Console.ReadLine());
				if(v < 1 || v > 4) {
					Console.WriteLine("Opção inválida!");
					return MenuOptions.NULL;
				}
				return (MenuOptions) v;
			} catch {
				Console.WriteLine("Entrada inválida!");
				return MenuOptions.NULL;
			}
		}

		public void Pause() {
			Console.WriteLine("\nPressione Enter para continuar...");
			Console.ReadLine();
		}

		public int AskForSelection(int maxIndex) {
			Console.Write($"Escolha o número da carta (1-{maxIndex}) ou 0 para cancelar: ");
			try {
				int v = Convert.ToInt32(Console.ReadLine());
				if(v < 0 || v > maxIndex) return -1;
				return v;
			} catch {
				return -1;
			}
		}

        public void MostrarMensagem(string mensagem) {
            Console.WriteLine(mensagem);
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
            foreach(string carta_s in cartas) {
                Carta? carta = JsonSerializer.Deserialize<Carta>(carta_s);
                if(carta == null) continue;

                MostrarCarta(carta);
            }
        }

        public bool ComprarCarta() {
            Console.Write("Voce deseja comprar essa carta? (s/n)\n> ");
            
            string resposta = Console.ReadLine() ?? "";
            resposta = resposta.ToLower();

            if(resposta == "s" || resposta == "sim") return true;
            else return false;
        }

        public string LerIdCarta()
        {
            Console.Write("> ");
            return Console.ReadLine() ?? "";
        }
	}
}

