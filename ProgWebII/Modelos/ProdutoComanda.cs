﻿namespace ProgWebII.Modelos
{
    public class ProdutoComanda
    {
        public int Id { get; set; }

        public Produto Produto { get; set; }

        public int ProdutoId { get; set; }

        public Comanda Comanda { get; set; }

        public int ComandaId { get; set; }
    }
}
