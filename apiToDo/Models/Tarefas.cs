using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {

        private static List<TarefaDTO> lstTarefasDB = new List<TarefaDTO>() 
        {
            new TarefaDTO {ID_TAREFA = 1, DS_TAREFA = "Fazer Compras"},
            new TarefaDTO {ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade Faculdade"},
            new TarefaDTO {ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no Github"}
        };

        // metodo para listar as tarefas
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return lstTarefasDB;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar tarefas: {ex.Message}", ex);
            }
        }

        // metodo para atualizar uma tarefa
        public List<TarefaDTO> AtualizarTarefa (TarefaDTO Request)
        {
            try 
            { 
                var tarefa = lstTarefasDB.FirstOrDefault(x => x.ID_TAREFA == Request.ID_TAREFA);

                if (tarefa == null)
                {
                    throw new Exception($"Tarefa com ID {Request.ID_TAREFA} não encontrada.");
                }

                tarefa.DS_TAREFA = Request.DS_TAREFA;
                return lstTarefasDB;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar tarefa: {ex.Message}", ex);
            }
        }

        // metodo para buscar uma tarefa
        public TarefaDTO BuscarTarefa(int ID_TAREFA)
        {
            try
            {
                var tarefa = lstTarefasDB.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                if (tarefa == null)
                {
                    throw new Exception($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }

                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar tarefa: {ex.Message}", ex);
            }
        }

        // metodo para inserir uma tarefa
        public List<TarefaDTO> InserirTarefa(TarefaDTO Request)
        {
            try
            {
                if (Request == null)
                    throw new ArgumentNullException(nameof(Request), "A tarefa enviada é nula.");

                lstTarefasDB.Add(Request);
                return lstTarefasDB;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir tarefa: {ex.Message}", ex);
            }
        }

        // metodo para deletar uma tarefa
        public List<TarefaDTO> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                // busca a tarefa com o ID fornecido na list
                var tarefa = lstTarefasDB.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                // verifica se a tarefa foi encontrada
                if (tarefa == null)
                {
                    // se nao encontrou, lança uma erro
                    throw new Exception($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }
                // remove a tarefa encontrada da list
                lstTarefasDB.Remove(tarefa);

                // retorna a list de tarefas atualizada
                return lstTarefasDB;
            }
            catch (Exception ex)
            {
                // exception para qualquer outro erro que possa ocorrer
                throw new Exception($"Erro ao deletar tarefa: {ex.Message}", ex);
            }
        }
    }
 }

