[HttpPost]
public ActionResult Validate(string Id,  string Pwd)
{
    if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Pwd))
    {
        throw new ArgumentNullException();
    }

    string userProfile = "MIS , Jerry";
    DateTime expired = DateTime.Now;

    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
      "Validate",
      expired,
      expired.AddMinutes(30),
      false,
      userProfile,
      FormsAuthentication.FormsCookiePath);

    FormsAuthentication.SetAuthCookie("Validate", false);
    string encrypt = FormsAuthentication.Encrypt(ticket);
    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encrypt));

    return RedirectToAction("", "Manage");
}


public ActionResult Logout()
{
    FormsAuthentication.SignOut();
    return RedirectToAction("", "Home");
}

//View
//@if (User.Identity.IsAuthenticated) {
// UI
//}
