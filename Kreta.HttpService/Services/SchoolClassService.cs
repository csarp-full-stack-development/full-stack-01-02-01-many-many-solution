﻿using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using System.Diagnostics;
using System.Net.Http.Json;

namespace Kreta.HttpService.Services
{
    public class SchoolClassService : BaseService<SchoolClass, SchoolClassDto>, ISchoolClassService
    {
        private readonly SubjectAssambler? _subjectAssambler;
        public SchoolClassService(IHttpClientFactory? httpClientFactory, SchoolClassAssambler? assambler, SubjectAssambler? subjectAssambler) : base(httpClientFactory, assambler)
        {
            _subjectAssambler = subjectAssambler;
        }

        public async Task<List<SchoolClass>> GetAllSchoolClassWithSubjectsAsync()
        {
            if (_httpClient is not null)
            {
                try
                {

                    List<SchoolClassDto>? resultDto = await _httpClient.GetFromJsonAsync<List<SchoolClassDto>>($"api/SchoolClass/withsubjects");
                    if (resultDto is not null)
                    {
                        List<SchoolClass> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<SchoolClass>();
        }

        public async Task<List<Subject>> GetSubjectNotStudiedInTheSchoolClass(Guid subjectId)
        {
            if (_httpClient is not null && _subjectAssambler is not null)
            {
                try
                {

                    List<SubjectDto>? resultDto = await _httpClient.GetFromJsonAsync<List<SubjectDto>>($"api/SchoolClass/notstudiedintheschoolclass/{subjectId}");
                    if (resultDto is not null)
                    {
                        List<Subject> result = resultDto.Select(entity => _subjectAssambler.ToModel(entity)).ToList();
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
