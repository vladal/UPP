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
	public class СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспечения:V82.Rest.СправочникиТест.СправочникТест
	{
		public static СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспечения/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос = null;
			try
			{
				СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос = Клиент.Get(new СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос;
		}
		public static СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспечения/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос = null;
			try
			{
				СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос = Клиент.Get(new СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос;
		}
		public static СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспечения/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос = null;
			try
			{
				СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос = Клиент.Get(new СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос;
		}
		public static void ЗаписатьНовый(СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспечения?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияОтвет = Клиент.Post(СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос);
		}
		public static void Записать(СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспечения?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияОтвет = Клиент.Put(СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос);
		}
		public static void Удалить(СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспечения?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияОтвет = Клиент.Delete(СпискиПрофессийДолжностейЛьготногоПенсионногоОбеспеченияЗапрос);
		}
	}
}