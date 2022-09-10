﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1.DATOS;
using Proyecto1.DATOS.Entidades;
using Proyecto1.DATOS.Repositorios;
using Proyecto1.DTO;

namespace Proyecto1.NEGOCIO
{
	public class PersonajeNegocio : IPersonajeNegocio 
	{
		private readonly IPersonajeRepositorio _personajeRepositorio;
		private readonly ICategoriaRepositorio _categoriaRepositorio;

		public PersonajeNegocio(IPersonajeRepositorio personajeRepositorio, ICategoriaRepositorio categoriaRepositorio)
		{
			_personajeRepositorio = personajeRepositorio;
			_categoriaRepositorio = categoriaRepositorio;
		}
		public List<PersonajeDTO> ObtenerTodos()
		{
			var listaDTO = new List<PersonajeDTO>();
			var listaEntidades = _personajeRepositorio.ObtenerTodos();
			foreach (var entidad in listaEntidades)
			{
				var nuevoPersonajeDTO = new PersonajeDTO()
				{
					Id = entidad.Id,
					Categoria = entidad.Categoria,
					FechaNacimiento = entidad.FechaNacimiento,
					Nombre = entidad.Nombre,
				};
				listaDTO.Add(nuevoPersonajeDTO);
			}

			return listaDTO;
		}

		public SelectList ObtenerCategoriasLista()
		{
			var categorias = _categoriaRepositorio.ObtenerTodas();
			var listadoCategorias = new SelectList(categorias, "Id", "Nombre");
			return listadoCategorias;
		}

        public void CrearPersonaje(PersonajeParaGuardarDTO personajeParaGuardarDTO)
        {
            var personaje = new Personaje 
				{ 
					Nombre = personajeParaGuardarDTO.Nombre,
					NombreReal = personajeParaGuardarDTO.NombreReal,
					CategoriaId = (int)personajeParaGuardarDTO.CategoriaId,
					FechaNacimiento = personajeParaGuardarDTO.FechaNacimiento == null ? null : Convert.ToDateTime(personajeParaGuardarDTO.FechaNacimiento),
					ImagenUrl = personajeParaGuardarDTO.ImagenUrl,
					SuperPoder = personajeParaGuardarDTO.SuperPoder
			};
            _personajeRepositorio.CrearPersonaje(personaje);
        }

        public PersonajeParaEditarDTO ObtenerPersonajePorId(int id)
        {
            var personaje = _personajeRepositorio.ObtenerPorId(id);
            var personajeDTO = new PersonajeParaEditarDTO 
			{
				Id = personaje.Id, 
				Nombre = personaje.Nombre,
				SuperPoder = personaje.SuperPoder,
				FechaNacimiento = personaje.FechaNacimiento,
				NombreReal = personaje.NombreReal,
				CategoriaId = personaje.CategoriaId,
				ImagenUrl = personaje.ImagenUrl
			};
            return personajeDTO;
        }

        public void ActualizarPersonaje(PersonajeParaEditarDTO personajeParaEditarDTO)
        {
            var personaje = new Personaje
			{
				Id = personajeParaEditarDTO.Id,
                Nombre = personajeParaEditarDTO.Nombre,
                NombreReal = personajeParaEditarDTO.NombreReal,
                CategoriaId = (int)personajeParaEditarDTO.CategoriaId,
                FechaNacimiento = personajeParaEditarDTO.FechaNacimiento == null ? null : Convert.ToDateTime(personajeParaEditarDTO.FechaNacimiento),
                ImagenUrl = personajeParaEditarDTO.ImagenUrl,
                SuperPoder = personajeParaEditarDTO.SuperPoder
            };
            _personajeRepositorio.ActualizarPersonaje(personaje);
        }
    }
}
