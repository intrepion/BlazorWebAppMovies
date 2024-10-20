﻿using System.Net.Http.Json;
using BlazorWebAppMovies.BusinessLogic.Entities.Dtos.Admin;

namespace BlazorWebAppMovies.BusinessLogic.Repositories.Admin.Client;

public class CastMemberMovieClientAdminRepository(HttpClient httpClient) : ICastMemberMovieAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<CastMemberMovieAdminDto?> AddAsync(CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/castMemberMovieAdmin", castMemberMovieAdminDto);

        return await result.Content.ReadFromJsonAsync<CastMemberMovieAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/castMemberMovieAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<CastMemberMovieAdminDto?> EditAsync(CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/castMemberMovieAdmin/{castMemberMovieAdminDto.Id}", castMemberMovieAdminDto);

        return await result.Content.ReadFromJsonAsync<CastMemberMovieAdminDto>();
    }

    public async Task<List<CastMemberMovieAdminDto>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<CastMemberMovieAdminDto>>($"/api/admin/castMemberMovieAdmin?userName={userName}");

        return result;
    }

    public async Task<CastMemberMovieAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<CastMemberMovieAdminDto>($"/api/admin/castMemberMovieAdmin/{id}?userName={userName}");

        return result;
    }
}
