using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.ProductionCompanies.Dtos;
using Cut_Roll_Movies.Core.ProductionCompanies.Models;

namespace Cut_Roll_Movies.Core.ProductionCompanies.Repositores;

public interface IProductionCompanyRepository: ISearchAsync<PagedResult<ProductionCompany>, ProductionCompanySearchRequest>, ICreateAsync<int, ProductionCompanyCreateDto>, IDeleteAsync<int, int>, IUpdateAsync<ProductionCompanyUpdateDto, int>
{
    
}
