using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IPredictionRepository
	{
		ICollection<Prediction> GetPredictions(PaginationDto paginationDto);
		Prediction GetPrediction(int id);
		bool AddPrediction(Prediction prediction);
		bool UpdatePrediction(Prediction prediction);
		bool DeletePrediction(int id);
		bool Save();
	}
}
