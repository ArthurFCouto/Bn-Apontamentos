using BN.Apontamentos.Domain.PlanosDeCorte.Schemas;
using BN.Apontamentos.Domain.Trechos.Schemas;

namespace BN.Apontamentos.Domain.Apontamentos.Schemas
{
    public class Apontamento
    {
        protected Apontamento() { }

        public Apontamento(
            PlanoDeCorte planoDeCorte,
            Trecho trecho,
            int matriculaUsuario,
            string tagReal,
            decimal metragemInicio,
            decimal metragemFim,
            string observacao,
            DateTime dataLancamento)
        {
            IdPlanoDeCorte = planoDeCorte.IdPlanoDeCorte;
            IdTrecho = trecho.IdTrecho;
            MatriculaUsuario = matriculaUsuario;

            PlanoDeCorte = planoDeCorte;
            Trecho = trecho;

            NumeroCircuito = trecho.Circuito.IdCircuito;
            IdentificacaoCabo = trecho.Nome;
            TagPrevisto = trecho.Bobina.Tag;
            TagReal = tagReal;
            Origem = trecho.Origem.Descricao;
            Destino = trecho.Destino.Descricao;
            Fase = trecho.Fase;
            ComprimentoFase = trecho.ComprimentoFase;
            ComprimentoTotal = 0;
            Secao = trecho.Bobina.Secao;
            MetragemInicio = metragemInicio;
            MetragemFim = metragemFim;
            Observacao = observacao;
            DataLancamento = dataLancamento;
            DataInclusao = DateTime.UtcNow;
        }

        public virtual int IdApontamento { get; set; }
        public virtual int NumeroCircuito { get; set; }
        public virtual string IdentificacaoCabo { get; set; }
        public virtual string TagPrevisto { get; set; }
        public virtual string TagReal { get; set; }
        public virtual string Origem { get; set; }
        public virtual string Destino { get; set; }
        public virtual char Fase { get; set; }
        public virtual decimal ComprimentoFase { get; set; }
        public virtual decimal ComprimentoTotal { get; set; }
        public virtual int Secao { get; set; }
        public virtual decimal MetragemInicio { get; set; }
        public virtual decimal MetragemFim { get; set; }
        public virtual string Observacao { get; set; }
        public virtual DateTime DataLancamento { get; set; }
        public virtual int IdPlanoDeCorte { get; set; }
        public virtual int IdTrecho { get; set; }
        public virtual int MatriculaUsuario { get; set; }
        public virtual DateTime DataInclusao { get; set; }
        public virtual DateTime? DataModificacao { get; set; }
        public virtual DateTime? DataInativacao { get; set; }

        public virtual PlanoDeCorte PlanoDeCorte { get; set; }
        public virtual Trecho Trecho { get; set; }

    }
}