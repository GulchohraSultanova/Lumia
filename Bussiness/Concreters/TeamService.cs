using Bussiness.Abstracts;
using Bussiness.Exceptions;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concreters
{
    public class TeamService : ITeamService
    {
        ITeamRepository _teamRepository;
        IWebHostEnvironment _webHostEnvironment;

        public TeamService(ITeamRepository teamRepository, IWebHostEnvironment webHostEnvironment)
        {
            _teamRepository = teamRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public void Create(Team team)
        {
           if (team == null)
            {
                throw new NotFoundException("", "Null ola bilmez!");
            }
           if(team.PhotoFile == null) {
                throw new NotNullException("PhotoFile", "Null ola bilmez!");
            }
            if (!team.PhotoFile.ContentType.Contains("image/"))
            {
                throw new FileContentTypeException("PhotoFile", "File tpi dogru deyil!");

            }
            string filename=team.PhotoFile.FileName;
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Team\" + filename;
            using(FileStream file =new FileStream(path, FileMode.Create))
            {
               team.PhotoFile.CopyTo(file);
            }
            team.ImgUrl = filename;
            _teamRepository.Add(team);
            _teamRepository.Commit();

        }

        public void Delete(int id)
        {
          var OldTeam=_teamRepository.Get(x=> x.Id == id);
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Team\" + OldTeam.ImgUrl;
            FileInfo fileInfo = new FileInfo(path);
            if(fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            _teamRepository.Delete(OldTeam);
            _teamRepository.Commit();


        }

        public List<Team> GetAllTeams(Func<Team, bool>? func)
        {
            return _teamRepository.GetAll(func);
        }

        public Team GetTeam(Func<Team, bool>? func)
        {
            return _teamRepository.Get(func);
        }

        public void Update(int id, Team team)
        {
            var updateTeam=_teamRepository.Get(x => x.Id == id);
            if (updateTeam == null)
            {
                throw new NotFoundException("", "Null ola bilmez!");
            }if(team.PhotoFile != null)
            {
                if (!team.PhotoFile.ContentType.Contains("image/"))
                {
                    throw new FileContentTypeException("PhotoFile", "File tpi dogru deyil!");

                }
                string filename = team.PhotoFile.FileName;
                string path = _webHostEnvironment.WebRootPath + @"\Upload\Team\" + filename;
                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    team.PhotoFile.CopyTo(file);
                }
                updateTeam.ImgUrl = filename;
            }
            else
            {
                team.ImgUrl=updateTeam.ImgUrl;
            }
            updateTeam.Name = team.Name;
            updateTeam.Description = team.Description;
            updateTeam.Position = team.Position;
            _teamRepository.Commit();
        }
    }
}
