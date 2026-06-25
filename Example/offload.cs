
app.MapGet("/hash", async () => {
    var result = await Task.Run(() => BCrypt.HashPassword("secret"));
    return result;
});