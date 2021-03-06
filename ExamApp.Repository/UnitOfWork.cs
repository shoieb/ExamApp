﻿using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExamApp.Repository;

namespace Test.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context;
        public UnitOfWork(AppDbContext appDbContext)
        {            
            context = appDbContext;
        }

        public UserRepository _userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(context);
                }
                return _userRepository;
            }
        }

        public EmployeeRepository _employeeRepository;
        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                {
                    this._employeeRepository = new EmployeeRepository(context);
                }
                return _employeeRepository;
            }
        }
        //
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
