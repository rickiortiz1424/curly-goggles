﻿using Ecommerce.DTO;
using Ecommer.WebAssembly.Servicio.Contrato;
using System.Net.Http.Json;

namespace Ecommer.WebAssembly.Servicio.Implementacion
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly HttpClient _httpClient;

        public CategoriaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Categoria/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{id}");
        }

        public async  Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Categoria/Lista/{buscar}");
        }

        public async Task<ResponseDTO<CategoriaDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Categoria/Obtener/{id}");
        }
    }
}
