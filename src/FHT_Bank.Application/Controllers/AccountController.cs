using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHT_Bank.Domain.Dtos;
using FHT_Bank.Domain.Interfaces;
using FHT_Bank.Domain.Models;
using FHT_Bank.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace FHT_Bank.Application.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.Select(x => x.Errors));

            var acc = await _accountService.Withdraw(accountDto);

            return Ok(acc);
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Depositar([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.Select(x => x.Errors));

            var acc = await _accountService.Deposit(accountDto);

            return Ok(acc);
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> Depositar([FromRoute] int accountId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.Select(x => x.Errors));

            var saldo = await _accountService.Balance(accountId);

            return Ok(saldo);
        }
    }
}