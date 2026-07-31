namespace Magic {

    class Carta {
        public enum Cores {
            INCOLOR, BRANCO, AZUL, PRETO, VERMELHO, VERDE
        };

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string? Descricao { get; set; }
        public string? CustoMana { get; set; }
        public int   ValorMana { get; set; }
        public int?  Poder { get; set; }
        public int?  Resistencia { get; set; }
        public Cores   Cor { get; set; }

        public float?  Preco { get; set; }

        public string OutputValuesString(){
            return (Nome + "§" + Tipo + "§" + Descricao + "§" + CustoMana + "§" + ValorMana + "§" + Poder + "§" + Resistencia + "§" + ((int)Cor) + "§" + Preco);
        }

        public void InputValuesString(string value){
            string[] valuesSplit = value.Split('§');
            Nome = valuesSplit[0];
            Tipo = valuesSplit[1];
            Descricao = valuesSplit[2];
            CustoMana = valuesSplit[3];
            ValorMana = Convert.ToInt32(valuesSplit[4]);
            Poder = Convert.ToInt32(valuesSplit[5]);
            Resistencia = Convert.ToInt32(valuesSplit[6]);
            Cor = (Cores)Convert.ToInt32(valuesSplit[7]);
            Preco = float.TryParse(valuesSplit[8]);
        }
    }

}