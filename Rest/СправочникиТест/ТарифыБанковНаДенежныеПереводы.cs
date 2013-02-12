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
	public class ТарифыБанковНаДенежныеПереводы:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ТарифыБанковНаДенежныеПереводыЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ТарифыБанковНаДенежныеПереводы/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ТарифыБанковНаДенежныеПереводыЗапрос ТарифыБанковНаДенежныеПереводыЗапрос = null;
			try
			{
				ТарифыБанковНаДенежныеПереводыЗапрос = Клиент.Get(new ТарифыБанковНаДенежныеПереводыЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ТарифыБанковНаДенежныеПереводыЗапрос;
		}
		public static ТарифыБанковНаДенежныеПереводыЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/ТарифыБанковНаДенежныеПереводы/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ТарифыБанковНаДенежныеПереводыЗапрос ТарифыБанковНаДенежныеПереводыЗапрос = null;
			try
			{
				ТарифыБанковНаДенежныеПереводыЗапрос = Клиент.Get(new ТарифыБанковНаДенежныеПереводыЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ТарифыБанковНаДенежныеПереводыЗапрос;
		}
		public static ТарифыБанковНаДенежныеПереводыЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ТарифыБанковНаДенежныеПереводы/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ТарифыБанковНаДенежныеПереводыЗапрос ТарифыБанковНаДенежныеПереводыЗапрос = null;
			try
			{
				ТарифыБанковНаДенежныеПереводыЗапрос = Клиент.Get(new ТарифыБанковНаДенежныеПереводыЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ТарифыБанковНаДенежныеПереводыЗапрос;
		}
		public static void ЗаписатьНовый(ТарифыБанковНаДенежныеПереводыЗапрос ТарифыБанковНаДенежныеПереводыЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ТарифыБанковНаДенежныеПереводы?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ТарифыБанковНаДенежныеПереводыОтвет = Клиент.Post(ТарифыБанковНаДенежныеПереводыЗапрос);
		}
		public static void Записать(ТарифыБанковНаДенежныеПереводыЗапрос ТарифыБанковНаДенежныеПереводыЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ТарифыБанковНаДенежныеПереводы?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ТарифыБанковНаДенежныеПереводыОтвет = Клиент.Put(ТарифыБанковНаДенежныеПереводыЗапрос);
		}
		public static void Удалить(ТарифыБанковНаДенежныеПереводыЗапрос ТарифыБанковНаДенежныеПереводыЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ТарифыБанковНаДенежныеПереводы?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ТарифыБанковНаДенежныеПереводыОтвет = Клиент.Delete(ТарифыБанковНаДенежныеПереводыЗапрос);
		}
	}
}