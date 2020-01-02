package myjava.smx.utils;

import javax.servlet.http.Cookie;

public class CookieUtil
{
	public static Cookie getCookie(String cookieName, Cookie[] cookies)
	{
		for (Cookie cookie: cookies)
		{
			if (cookieName.equals(cookie.getName()))
			{
				return cookie;
			}
		}
		return null;
	}
}
