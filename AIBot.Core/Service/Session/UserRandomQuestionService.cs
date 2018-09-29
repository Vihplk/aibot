using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBot.Core.Dto;
using AIBot.Core.Infrastructure;
using AIBot.Core.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace AIBot.Core.Service.Session
{
    public class UserRandomQuestionService: IUserRandomQuestionService
    {
        private readonly IUnitOfWork _uow;
        public UserRandomQuestionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<UserRandomQuestionDto>> ReadRandomQuestionAnswer()
        {
            return (await _uow.UserRandomQuestionRepository
                    .TableAsNoTracking.ToListAsync()).Select(x => AutoMapper.Mapper.Map<UserRandomQuestionDto>(x))
                .ToList();

        }
    }
}
