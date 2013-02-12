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
	public class ВидыОбщественноПолезнойДеятельности:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ВидыОбщественноПолезнойДеятельностиЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ВидыОбщественноПолезнойДеятельности/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыОбщественноПолезнойДеятельностиЗапрос ВидыОбщественноПолезнойДеятельностиЗапрос = null;
			try
			{
				ВидыОбщественноПолезнойДеятельностиЗапрос = Клиент.Get(new ВидыОбщественноПолезнойДеятельностиЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыОбщественноПолезнойДеятельностиЗапрос;
		}
		public static ВидыОбщественноПолезнойДеятельностиЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/ВидыОбщественноПолезнойДеятельности/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыОбщественноПолезнойДеятельностиЗапрос ВидыОбщественноПолезнойДеятельностиЗапрос = null;
			try
			{
				ВидыОбщественноПолезнойДеятельностиЗапрос = Клиент.Get(new ВидыОбщественноПолезнойДеятельностиЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыОбщественноПолезнойДеятельностиЗапрос;
		}
		public static ВидыОбщественноПолезнойДеятельностиЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ВидыОбщественноПолезнойДеятельности/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыОбщественноПолезнойДеятельностиЗапрос ВидыОбщественноПолезнойДеятельностиЗапрос = null;
			try
			{
				ВидыОбщественноПолезнойДеятельностиЗапрос = Клиент.Get(new ВидыОбщественноПолезнойДеятельностиЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыОбщественноПолезнойДеятельностиЗапрос;
		}
		public static void ЗаписатьНовый(ВидыОбщественноПолезнойДеятельностиЗапрос ВидыОбщественноПолезнойДеятельностиЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ВидыОбщественноПолезнойДеятельности?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыОбщественноПолезнойДеятельностиОтвет = Клиент.Post(ВидыОбщественноПолезнойДеятельностиЗапрос);
		}
		public static void Записать(ВидыОбщественноПолезнойДеятельностиЗапрос ВидыОбщественноПолезнойДеятельностиЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ВидыОбщественноПолезнойДеятельности?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыОбщественноПолезнойДеятельностиОтвет = Клиент.Put(ВидыОбщественноПолезнойДеятельностиЗапрос);
		}
		public static void Удалить(ВидыОбщественноПолезнойДеятельностиЗапрос ВидыОбщественноПолезнойДеятельностиЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ВидыОбщественноПолезнойДеятельности?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыОбщественноПолезнойДеятельностиОтвет = Клиент.Delete(ВидыОбщественноПолезнойДеятельностиЗапрос);
		}
	}
}