﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AgendamentoServico.Client.Dtos;
using Newtonsoft.Json;

namespace AgendamentoServico.Client.Service
{
    public class ProfissionalService
    {
        public void Cadastrar(Profissional profissional)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                profissional = profissional,                
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;                
                response = httpClient.PostAsync($"https://localhost:44311/profissional/create", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Atualizar(int id, Profissional profissional)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                profissional = profissional,
                id
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;                
                response = httpClient.PutAsync($"https://localhost:44311/profissional/update", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Deletar(int id, ProfissionalDto profissional)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                profissional = profissional,
                id
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;                
                response = httpClient.DeleteAsync($"https://localhost:44311/profissional/delete").Result;

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}