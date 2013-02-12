﻿
using System;
using System.Globalization;
using System.Collections.Generic;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceClient.Web;
using V82.Справочники;

namespace V82.Rest.СправочникиТест
{
	public class ПоказателиАнализовНоменклатуры:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ПоказателиАнализовНоменклатурыЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ПоказателиАнализовНоменклатуры/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ПоказателиАнализовНоменклатурыЗапрос ПоказателиАнализовНоменклатурыЗапрос = null;
			try
			{
				ПоказателиАнализовНоменклатурыЗапрос = Клиент.Get(new ПоказателиАнализовНоменклатурыЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ПоказателиАнализовНоменклатурыЗапрос;
		}
		public static ПоказателиАнализовНоменклатурыЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/ПоказателиАнализовНоменклатуры/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ПоказателиАнализовНоменклатурыЗапрос ПоказателиАнализовНоменклатурыЗапрос = null;
			try
			{
				ПоказателиАнализовНоменклатурыЗапрос = Клиент.Get(new ПоказателиАнализовНоменклатурыЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ПоказателиАнализовНоменклатурыЗапрос;
		}
		public static ПоказателиАнализовНоменклатурыЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ПоказателиАнализовНоменклатуры/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ПоказателиАнализовНоменклатурыЗапрос ПоказателиАнализовНоменклатурыЗапрос = null;
			try
			{
				ПоказателиАнализовНоменклатурыЗапрос = Клиент.Get(new ПоказателиАнализовНоменклатурыЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ПоказателиАнализовНоменклатурыЗапрос;
		}
		public static void ЗаписатьНовый(ПоказателиАнализовНоменклатурыЗапрос ПоказателиАнализовНоменклатурыЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ПоказателиАнализовНоменклатуры?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ПоказателиАнализовНоменклатурыОтвет = Клиент.Post(ПоказателиАнализовНоменклатурыЗапрос);
		}
		public static void Записать(ПоказателиАнализовНоменклатурыЗапрос ПоказателиАнализовНоменклатурыЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ПоказателиАнализовНоменклатуры?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ПоказателиАнализовНоменклатурыОтвет = Клиент.Put(ПоказателиАнализовНоменклатурыЗапрос);
		}
		public static void Удалить(ПоказателиАнализовНоменклатурыЗапрос ПоказателиАнализовНоменклатурыЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ПоказателиАнализовНоменклатуры?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ПоказателиАнализовНоменклатурыОтвет = Клиент.Delete(ПоказателиАнализовНоменклатурыЗапрос);
		}
	}
}