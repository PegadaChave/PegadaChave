using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PegadaChave.Models.DTOs
{
    public class ProdutoDTO
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public CategoriaProduto CategoriaProduto { get; set; }
        public TamanhoProduto TamanhoProduto { get; set; }
        public CondicaoProduto CondicaoProduto { get; set; }
        public float PrecoProduto { get; set; }
        public string ImagemProduto { get; set; }
        public int EstoqueProduto { get; set; }
    }

    public enum CategoriaProduto
    {
        Sapato,
        Camisa,
        Calça
    }

    public enum TamanhoProduto
    {
        P,
        M,
        G
    }

    public enum CondicaoProduto
    {
        Usado,
        Novo,
        Recondicionado
    }
}