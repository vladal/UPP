﻿Ext.require(['Данные.Отчеты.СведенияОРасходахНаПроизводствоИПродажуПродукции'], function () 
{
	Ext.define('Отчеты.СведенияОРасходахНаПроизводствоИПродажуПродукции.ФормаОтчета',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:820px;height:558px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	resizable: false,
	title: 'Сведения о расходах на производство и продажу продукции (товаров, работ и услуг)',
	
	layout: {type: "fit",align: "stretch"},
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:0px;top:1px;width:820px;height:46px;',
			height: 46,width: 820,
			tabBar:{hidden:true},
			items:
			[
				{
					title:'Страница1',
					items:
					[
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'НачалоПериода',
			width: 80,
			height: 19,
			style: 'position:absolute;left:8px;top:20px;width:80px;height:19px;',
		},
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'КонецПериода',
			width: 80,
			height: 19,
			style: 'position:absolute;left:98px;top:20px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьДатаНач',
			text: 'Период:',
			style: 'position:absolute;left:8px;top:0px;width:57px;height:19px;text-align:left;',
		},
		{
			xtype: 'label',
			name: 'НадписьДатаКон',
			text: '—',
			style: 'position:absolute;left:88px;top:20px;width:10px;height:19px;text-align:center;',
		},
		{
			xtype: 'button',
			name: 'КнопкаНастройкаПериода',
			text: '...',
			style: 'position:absolute;left:182px;top:20px;width:19px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьОрганизация',
			text: 'Организация:',
			style: 'position:absolute;left:212px;top:0px;width:74px;height:19px;text-align:left;',
		},
		{
			xtype: 'combobox',
			style: 'position:absolute;left:212px;top:20px;width:220px;height:19px;',
			width: 220,
			height: 19,
		},
					]
				},
			]
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:2px;top:47px;width:490px;height:26px;',
			items:
			[
				{
					text:'Сформировать отчет',
				},
				'-',
				{
					text:'Печать...',
				},
				'-',
				{
					text:'Сохранить как...',
				},
				'-',
				{
					text:'Выгрузить в файл',
				},
			]
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:561px;top:47px;width:256px;height:25px;',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'Настройка',
				},
				'-',
				{
					text:'Загрузить настройки отчета',
				},
				{
					text:'Сохранить настройки отчета',
				},
				'-',
				{
					text:'Коды ОКПД',
				},
				{
					text:'Идентификация по ОКПД',
				},
				'-',
				{
					text:'Справка',
				},
			]
		},
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:514px;top:73px;width:306px;height:485px;',
			height: 485,width: 306,
			tabBar:{hidden:true},
			items:
			[
				{
					title:'Страница1',
					items:
					[
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:0px;top:27px;width:306px;height:458px;',
			height: 458,width: 306,
			items:
			[
				{
					title:'Отбор',
					items:
					[
		{
			id: 'Отбор',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:31px;width:292px;height:115px;',
			height: 115,width: 292,
			columns:
			[
				{
					text:'',
					width:'22',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Поле',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Поле',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляПодробногоОтображенияГруппы',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияГруппы',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляКраткогоОтображенияГруппы',
					flex:1,
				},
				{
					text:'Поле',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляПодробногоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляПодробногоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляКраткогоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляКраткогоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Режим отображения',
					width:'75',
					dataIndex:'РежимОтображенияДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляПодробногоОтображенияГруппыГлавногоОтбора',
					flex:1,
				},
				{
					text:'Режим отображения',
					width:'75',
					dataIndex:'РежимОтображенияДляПодробногоОтображенияГруппыГлавногоОтбора',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияГруппыГлавногоОтбора',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляКраткогоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Режим отображения',
					width:'75',
					dataIndex:'РежимОтображенияДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/СведенияОРасходахНаПроизводствоИПродажуПродукции/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ПредставлениеДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ЛевоеЗначениеДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ВидыСравненияДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ПравоеЗначениеДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ТипДляПодробногоОтображенияГруппы',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияГруппы',
					},
					{
						name:'ТипДляКраткогоОтображенияГруппы',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПрименениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ВидыСравненияДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПрименениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ТипДляПодробногоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ПрименениеДляПодробногоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ТипДляКраткогоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ПрименениеДляКраткогоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'РежимОтображенияДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'ТипДляПодробногоОтображенияГруппыГлавногоОтбора',
					},
					{
						name:'РежимОтображенияДляПодробногоОтображенияГруппыГлавногоОтбора',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияГруппыГлавногоОтбора',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					},
					{
						name:'ВидыСравненияДляКраткогоОтображенияЭлементаСДатой',
					},
					{
						name:'ПравоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПрименениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ВидыСравненияДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПрименениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'РежимОтображенияДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('Отбор');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.СведенияОРасходахНаПроизводствоИПродажуПродукции.ФормаОтчетаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.СведенияОРасходахНаПроизводствоИПродажуПродукции.ФормаОтчетаСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:6px;top:6px;width:292px;height:24px;',
			items:
			[
				{
					text:'',
				},
				{
					text:'',
				},
			]
		},
					]
				},
				{
					title:'Редактирование параметров',
					items:
					[
		{
			id: 'ПараметрыДанных',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:29px;width:292px;height:137px;',
			height: 137,width: 292,
			columns:
			[
				{
					text:'',
					width:'22',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Параметр',
					width:'131',
					dataIndex:'Параметр',
					flex:1,
				},
				{
					text:'Значение',
					width:'136',
					dataIndex:'Значение',
					flex:1,
				},
				{
					text:'Параметр',
					width:'134',
					dataIndex:'ПараметрСДатой',
					flex:1,
				},
				{
					text:'Значение',
					width:'67',
					dataIndex:'ЗначениеСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'67',
					dataIndex:'ДатаЗначениеСДатой',
					flex:1,
				},
				{
					text:'Дата начала',
					width:'134',
					dataIndex:'ДатаНачала',
					flex:1,
				},
				{
					text:'Дата окончания',
					width:'134',
					dataIndex:'ДатаОкончания',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/СведенияОРасходахНаПроизводствоИПродажуПродукции/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'Параметр',
					},
					{
						name:'Значение',
					},
					{
						name:'ПараметрСДатой',
					},
					{
						name:'ЗначениеСДатой',
					},
					{
						name:'ДатаЗначениеСДатой',
					},
					{
						name:'ДатаНачала',
					},
					{
						name:'ДатаОкончания',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ПараметрыДанных');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.СведенияОРасходахНаПроизводствоИПродажуПродукции.ФормаОтчетаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.СведенияОРасходахНаПроизводствоИПродажуПродукции.ФормаОтчетаСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'checkbox',
			boxLabel: 'Выводить забалансовые счета',
			style: 'position:absolute;left:5px;top:6px;width:292px;height:15px;',
		},
					]
				},
			]
		},
		{
			xtype: 'fieldset',
			title: '',
			style: 'position:absolute;left:0px;top:0px;width:306px;height:42px;',
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:6px;top:2px;width:297px;height:24px;',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'Восстановить',
				},
				'-',
				{
					text:'ЗакрытьПанельНастроек',
				},
			]
		},
		{
			xtype: 'label',
			name: 'Надпись6',
			text: 'Панель настроек',
			style: 'position:absolute;left:6px;top:5px;width:91px;height:18px;text-align:left;',
		},
					]
				},
			]
		},
		],
	}],
	dockedItems:
	[
	]
	});
});