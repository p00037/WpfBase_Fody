using EntityFrameworkBase;
using ExtensionsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using WpfBase.Domain.Models.Accounts;
using WpfBase.UseCase.Exceptions;

namespace WpfBase.UseCase.UseCases.Accounts
{
    public class AccountUseCase
    {
        IUnitOfWork unitOfWork;
        IM_AccountRepository m_AccountRepository;

        public AccountUseCase(IUnitOfWork unitOfWork, IM_AccountRepository m_AccountRepository)
        {
            this.m_AccountRepository = m_AccountRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool IsNoData()
        {
            if (this.m_AccountRepository.GetAll().ToList().Any())
            {
                return false;
            }

            return true;
        }

        public M_AccountEntity Get(Guid id)
        {
            return this.m_AccountRepository.Get(id);
        }

        public IEnumerable<M_AccountEntity> GetList(MstAccountSearchEntity searchEntity)
        {
            return this.m_AccountRepository.GetList(e => e.LoginId.Contains(searchEntity.LoginId.NullToValue(""))).OrderBy(e => e.LoginId).ToList();
        }

        public void CheckLogin(M_AccountEntity entity)
        {
            if (this.m_AccountRepository.GetList(e => e.LoginId == entity.LoginId && e.Password == entity.Password).Any())
            {
                return;
            }

            throw new AuthenticationException("ログインIDまたはパスワードが違います。");
        }

        public void Register(M_AccountEntity entity)
        {
            CheckValidationError(entity);

            try
            {
                unitOfWork.Begin();
                this.m_AccountRepository.Add(entity);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public void Update(M_AccountEntity entity)
        {
            CheckValidationError(entity);

            try
            {
                unitOfWork.Begin();
                this.m_AccountRepository.Update(entity);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public void Delete(M_AccountEntity entity)
        {
            try
            {
                unitOfWork.Begin();
                this.m_AccountRepository.Remove(entity);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        private void CheckValidationError(M_AccountEntity entity)
        {
            var errorMessage = new List<string>();
            errorMessage.AddRange(entity.GetValidationErrorMessages());
            if (errorMessage.Count() > 0) throw new SaveErrorMessageExcenption(errorMessage.ConcatWith(Environment.NewLine));
        }
    }
}
