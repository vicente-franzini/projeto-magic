namespace Magic {

    class Carta {
        public enum Cores {
            INCOLOR, BRANCO, AZUL, PRETO, VERMELHO, VERDE
        };

        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? Descricao { get; set; }
        public string? CustoMana { get; set; }
        public float   ValorMana { get; set; }
        public float?  Poder { get; set; }
        public float?  Resistencia { get; set; }
        public Cores   Cor { get; set; }

        public float?  Preco { get; set; }
    }

}