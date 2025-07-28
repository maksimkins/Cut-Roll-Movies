using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.ProductionCompanies.Dtos;
using Cut_Roll_Movies.Core.ProductionCompanies.Models;

namespace Cut_Roll_Movies.Core.ProductionCompanies.Repositores;

public interface IProductionCompanyRepository: ISearchAsync<PagedResult<ProductionCompany>, ProductionCompanySearchRequest>,
ICreateAsync<Guid, ProductionCompanyCreateDto>, IDeleteAsync<Guid, Guid?>, IUpdateAsync<ProductionCompanyUpdateDto, Guid>, IGetByIdAsync<ProductionCompany, Guid>
{
    
}
