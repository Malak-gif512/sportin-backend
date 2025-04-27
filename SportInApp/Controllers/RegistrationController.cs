using Microsoft.AspNetCore.Mvc;
using SportInApp.Data;
using SportInApp.Models;
using SportInApp.Services;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly SportInDbContext _context;
    private readonly IEmailService _emailService;

    public RegistrationController(SportInDbContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Registration registration)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            // Send email
            string subject = "New Registration!";
            string body = $"Name: {registration.Name}\nRole: {registration.Role}\nEmail: {registration.Email}\nPhone: {registration.Phone}\nSport: {registration.Sport}\nManager Email: {registration.ManagerEmail}";
            await _emailService.SendEmailAsync("malakhussein635@gmail.com", subject, body);

            return Ok(new { message = "Registration successful", registration = registration });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    [HttpPost("contact")]
    public async Task<IActionResult> Contact([FromBody] ContactUs contact)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            _context.ContactUs.Add(contact);
            await _context.SaveChangesAsync();

            // Send email
            string subject = "New Contact Message!";
            string body = $"Name: {contact.Name}\nEmail: {contact.Email}\nMessage: {contact.Message}";
            await _emailService.SendEmailAsync("malakhussein635@gmail.com", subject, body);

            return Ok(new { message = "Contact message sent" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }
}
