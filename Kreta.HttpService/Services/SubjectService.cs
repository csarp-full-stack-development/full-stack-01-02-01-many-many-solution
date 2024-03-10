using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using System.Diagnostics;
using System.Net.Http.Json;

namespace Kreta.HttpService.Services
{
    public class SubjectService : BaseService<Subject, SubjectDto>, ISubjectService
    {
        public SubjectService(IHttpClientFactory? httpClientFactory, SubjectAssambler assambler) : base(httpClientFactory, assambler)
        {
        }

        public async Task<List<Subject>> SelectAllWithSchoolClassAsync()
        {
            if (_httpClient is not null)
            {
                try
                {

                    List<SubjectDto>? resultDto = await _httpClient.GetFromJsonAsync<List<SubjectDto>>($"api/Subject/withschoolclass");
                    if (resultDto is not null)
                    {
                        List<Subject> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Subject>();
        }
    }
}
