﻿namespace ProgWebII.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public List<Comanda> Comandas { get; set; }
    }
}
