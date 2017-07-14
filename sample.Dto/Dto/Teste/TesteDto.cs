using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Sample.Dto
{
	public class TesteDto  : DtoBase
	{
	
        

        public virtual int TesteId {get; set;}

        [Required(ErrorMessage="Teste - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Teste - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}


		
	}
}