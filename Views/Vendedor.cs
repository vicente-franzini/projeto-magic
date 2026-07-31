namespace Magic {

    class VendedorView
    {
        public int Menu()
        {
            Console.WriteLine("\n===== MENU DO VENDEDOR =====");
            Console.WriteLine("1 - Colocar carta à venda");
            Console.WriteLine("2 - Listar minhas cartas");
            Console.WriteLine("3 - Remover carta");
            Console.WriteLine("0 - Voltar");

            Console.Write("Opção: ");

            return Convert.ToInt32(Console.ReadLine());
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

        public string LerIdCarta()
        {
            Console.Write("Id da carta: ");
            return Console.ReadLine()!;
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public void MostrarLista(string[] cartas)
        {
            Console.WriteLine("\n=== Cartas anunciadas ===");

            foreach(string carta in cartas)
                Console.WriteLine(carta);
        }
    }

}