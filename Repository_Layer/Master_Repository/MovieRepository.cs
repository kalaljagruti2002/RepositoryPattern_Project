using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Layer.Master_Interface;
using Data_Context_Layers.Dbconnection;
using Model_Layer.Master_Model;

namespace Repository_Layer.Master_Repository
{
	public class MovieRepository:I_Movie
	{
		JagrutiDBEntities dbcontext=new JagrutiDBEntities();
		public string SaveUpdate(Movie _movie)

		{
			try
			{
				Data_Context_Layers.Dbconnection.Movy obj=new Data_Context_Layers.Dbconnection.Movy();
				if(_movie.Movie_ID==0)
				{
					obj.Movie_Name=_movie.Movie_Name;
					obj.Movie_Ticket=_movie.Movie_Ticket;
					obj.Hero=_movie.Hero;
					obj.Heroin=_movie.Heroin;
					obj.Director=_movie.Director;
					dbcontext.Entry(obj).State = System.Data.Entity.EntityState.Added;
				}
				else
				{
					obj.Movie_ID = _movie.Movie_ID;
					obj.Movie_Name = _movie.Movie_Name;
					obj.Movie_Ticket = _movie.Movie_Ticket;
					obj.Hero = _movie.Hero;
					obj.Heroin = _movie.Heroin;
					obj.Director = _movie.Director;
					dbcontext.Entry(obj).State = System.Data.Entity.EntityState.Modified;

				}
				dbcontext.SaveChanges();	
				return "";
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<Movie> List()
		{
			try
			{
				var res = dbcontext.Movies.ToList();
				List<Model_Layer.Master_Model.Movie> listobj=new List<Model_Layer.Master_Model.Movie>();
                foreach (var item in res)
                {
					Model_Layer.Master_Model.Movie obj=new Model_Layer.Master_Model.Movie();
					obj.Movie_ID = item.Movie_ID;
					obj.Movie_Name = item.Movie_Name;
					obj.Movie_Ticket = item.Movie_Ticket;
					obj.Hero = item.Hero;
					obj.Heroin = item.Heroin; 
					obj.Director = item.Director;
					listobj.Add(obj);
				}
				return listobj;

            }
			catch (Exception ex)
			{
				throw ex;
			}
		
		}
		public Movie Edit(int id)
		{
			try
			{
				var res=dbcontext.Movies.Where(x=>x.Movie_ID == id).FirstOrDefault();
				Model_Layer.Master_Model.Movie obj = new Model_Layer.Master_Model.Movie();
				obj.Movie_ID = res.Movie_ID;
				obj.Movie_Name = res.Movie_Name;
				obj.Movie_Ticket = res.Movie_Ticket;
				obj.Hero = res.Hero;
				obj.Heroin = res.Heroin;
				obj.Director = res.Director;
				return obj;

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int Delete(int id)
		{
			try
			{
				var res= dbcontext.Movies.Where(x=> x.Movie_ID == id).FirstOrDefault();
				dbcontext.Movies.Remove(res);
				dbcontext.SaveChanges();
				return 1;

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

	}
}
