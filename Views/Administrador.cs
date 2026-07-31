namespace Magic{
    class AdmView{
        public enum OperationOptions {
            NULL, CREATE, SEARCH, LIST, UPDATE, DELETE, EXIT
        };

        public void GetOperationOption(){
            OperationOptions finalOption = OperationOptions.NULL;
            
            while(finalOption < OperationOptions.CREATE || finalOption > OperationOptions.EXIT) {
                Console.Write(
                    "[Escolha uma operação]\n" +
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
            Carta c = new Carta();

            Console.Write("Insira o nome da carta:\n>");
            c.Nome = Console.ReadLine();

            Console.Write("Insira o tipo da carta:\n>");
            c.Tipo = Console.ReadLine();

            Console.Write("Insira a descrição da carta:\n>");
            c.Descricao = Console.ReadLine();

            Console.Write("Insira o custo (em extenso) da carta:\n>");
            c.CustoMana = Console.ReadLine();

            Console.Write("Insira o custo de mana convertido da carta:\n>");
            c.ValorMana = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insira o poder da carta:\n>");
            c.Poder = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insira a resistência da carta:\n>");
            c.Resistencia = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insira a cor da carta:\n0 - Incolor\n1 - Branco\n2 - Azul\n3 - Preto\n4 - Vermelho\n5 - Verde\n>");
            c.Cor = (c.Cores) Convert.ToInt32(Console.ReadLine());

            return c;
        }

        public string GetCardName(){
            Console.Write("Insira o nome da carta:\n>");
            return Console.ReadLine();
        }

        public void PrintCard(Carta c){
            Console.WriteLine(
                c.Nome + "\n" +
                "Tipo: " + c.Tipo + "\n" +
                "Descrição: " + c.Descricao + "\n" +
                "Custo de Mana: " + c.CustoMana + "\n" +
                "Custo Convertido de Mana: " + c.Descricao + "\n" +
                "Poder: " + c.Descricao + "\n" +
                "Resistência: " + c.Descricao + "\n"
            );
        }
    } 
}