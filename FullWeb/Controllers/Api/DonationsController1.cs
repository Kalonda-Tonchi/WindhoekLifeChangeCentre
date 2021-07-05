using System;
using FullWeb.Data;
using System.Collections.Generic;
using System.Linq;
using FullWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using FullWeb.Dtos;


namespace FullWeb.Controllers.Api
{
    public class DonationsController1 : Controller
    {
        private ApplicationDbContext _context;

        public DonationsController1(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationDto>>> GetDonations()
        {
            var donation = await _context.Donation.Include(d => d.Product).Include(d => d.Project).ToList().Select(Mapper.Map<Donation, DonationDto>);
            return Ok(donation);
        }

        // GET: api/Donations/1
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationDto>> GetDonations(int id)
        {
            var donation = await _context.Donation.SingleOrDefaultAsync(m => m.Id == id);

            if (donation == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<DonationDto, Donation>(donation));
        }

        // POST: api/Donations
        [HttpPost]
        public async Task<ActionResult<DonationDto>> CreateDonation(DonationDto donationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var donation = Mapper.Map<DonationDto, Donation>(donationDto);
            _context.Donation.Add(donation);
            _context.SaveChanges();

            donationDto.Id = donation.Id;

            return CreatedAtAction(nameof(GetDonations), new { id = donation.Id }, donationDto);


        }

        // PUT /api/Donations/1
        [HttpPut("{id}")]
        public async Task<ActionResult<DonationDto>> UpdateClientele(int id, DonationDto donationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var donationInDb = _context.Donation.SingleOrDefault(d => d.Id == id);

            if (donationInDb == null)
                return NotFound();

            Mapper.Map(donationDto, donationInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE api/donations/1
        [HttpDelete]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            var donationInDb = _context.Donation.SingleOrDefault(d => d.Id == id);

            if (donationInDb == null)
                return NotFound();

            _context.Donation.Remove(donationInDb);
            _context.SaveChanges();

            return Ok();
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donation = await _context.Donation.FindAsync(id);
            _context.Donation.Remove(donation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonationExists(int id)
        {
            return _context.Donation.Any(e => e.Id == id);
        }
    }
}
