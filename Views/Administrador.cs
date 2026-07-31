namespace Magic{
    class AdmView{
        public enum OperationOptions {
            NULL, CREATE, SEARCH, LIST, UPDATE, DELETE, EXIT
        };

        public OperationOptions GetOperationOption(){
            OperationOptions finalOption = OperationOptions.NULL;
            
            while(finalOption < OperationOptions.CREATE || finalOption > OperationOptions.EXIT) {
                MostrarCabecalho("Administrador");
                Console.Write(
                    " 1 - Cadastrar nova carta\n" +
                    " 2 - Pesquisar por uma carta\n" +
                    " 3 - Listar todas as cartas\n" +
                    " 4 - Editar o cadastro de uma carta\n" +
                    " 5 - Excluir uma carta\n" +
                    " 6 - Sair\n\n" +
                    "> "
                );

                try { finalOption = (OperationOptions) Convert.ToUInt32(Console.ReadLine()); }
                catch (Exception e) {
                    if(e is FormatException) {
                        Console.WriteLine("Digite um número!");
                    }
                }

                if(finalOption < OperationOptions.CREATE || finalOption > OperationOptions.EXIT) {
                    Console.WriteLine("Operação inválida!");
                }
            }

            return finalOption;
        }

        public Carta GetCardValues(){
            MostrarCabecalho("Digite os valores da carta");
            Carta c = new Carta();

            Console.Write("Insira o nome da carta:\n> ");
            c.Nome = Console.ReadLine() ?? "N/D";

            Console.Write("Insira o tipo da carta:\n> ");
            c.Tipo = Console.ReadLine() ?? "N/D";

            Console.Write("Insira a descrição da carta:\n> ");
            c.Descricao = Console.ReadLine() ?? "N/D";

            Console.Write("Insira o custo (em extenso) da carta:\n> ");
            c.CustoMana = Console.ReadLine() ?? "N/D";

            Console.Write("Insira o custo de mana convertido da carta:\n> ");
            c.ValorMana = Convert.ToSingle(Console.ReadLine() ?? "0");

            string? res = "";

            Console.Write("Insira o poder da carta:\n> ");
            res = Console.ReadLine();
            if(!String.IsNullOrWhiteSpace(res))
                c.Poder = Convert.ToSingle(res);

            Console.Write("Insira a resistência da carta:\n> ");
            res = Console.ReadLine();
            if(!String.IsNullOrWhiteSpace(res))
                c.Resistencia = Convert.ToSingle(res);

            Carta.Cores cor;
            while(true) {
                Console.Write("Insira a cor da carta (Incolor/Branco/Azul/Preto/Vermelho/Verde)\n> ");
                if(Enum.TryParse<Carta.Cores>(Console.ReadLine(), true, out cor)) break;
            }
            c.Cor = cor;

            return c;
        }

        public string? GetCardName(){
            Console.Write("Insira o nome da carta:\n> ");
            return Console.ReadLine();
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

        public void MostrarCabecalho(string title) {
			Console.Clear();
			Console.WriteLine("=== " + title + " ===\n");
		}

        public void Pause() {
			Console.WriteLine("\nPressione Enter para continuar...");
			Console.ReadLine();
		}
    } 
}