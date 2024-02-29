using FluentValidation;
using ListaTarefa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Service.Validators
{
    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator()
        {
            RuleFor(tarefa => tarefa.Descricao)
                .NotEmpty().WithMessage("A descrição da tarefa é obrigatória.");

            RuleFor(tarefa => tarefa.Titulo)
                .NotEmpty().WithMessage("O título da tarefa é obrigatório.");

            RuleFor(tarefa => tarefa.DataVencimento)
                .NotEmpty().WithMessage("A data de vencimento da tarefa é obrigatória.")
                .Must(IsDataFutura).WithMessage("Selecione uma data futura");

            RuleFor(tarefa => tarefa.Status)
                .IsInEnum().WithMessage("Status inválido").NotEmpty()
                .WithMessage("Status da tarefa é obrigatorio");
        }

        private static bool IsDataFutura(DateTime dataVencimento)
        {
            return dataVencimento >= DateTime.Today;
        }
    }
}
