﻿using System.Net.Http.Json;
using BlazorWebAppMovies.BusinessLogic.Entities.Dtos.Admin;

namespace BlazorWebAppMovies.BusinessLogic.Repositories.Admin.Client;

public class CastMemberClientAdminRepository(HttpClient httpClient) : ICastMemberAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<CastMemberAdminDto?> AddAsync(CastMemberAdminDto castMemberAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/castMemberAdmin", castMemberAdminDto);

        return await result.Content.ReadFromJsonAsync<CastMemberAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/castMemberAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<CastMemberAdminDto?> EditAsync(CastMemberAdminDto castMemberAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/castMemberAdmin/{castMemberAdminDto.Id}", castMemberAdminDto);

        return await result.Content.ReadFromJsonAsync<CastMemberAdminDto>();
    }

    public async Task<List<CastMemberAdminDto>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<CastMemberAdminDto>>($"/api/admin/castMemberAdmin?userName={userName}");

        return result;
    }

    public async Task<CastMemberAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<CastMemberAdminDto>($"/api/admin/castMemberAdmin/{id}?userName={userName}");

        return result;
    }
}
