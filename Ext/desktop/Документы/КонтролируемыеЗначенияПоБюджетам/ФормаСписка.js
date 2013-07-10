﻿Ext.define('Документы.КонтролируемыеЗначенияПоБюджетам.ФормаСписка',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:780px;height:421px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Контролируемые значения по бюджетам',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'ДокументСписок',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:764px;height:380px;',
			height: 380,width: 764,
			columns:
			[
				{
					text:'',
					width:'32',
					dataIndex:'Картинка',
					flex:1,
				},
				{
					text:'Дата',
					width:'132',
					dataIndex:'Дата',
					flex:1,
				},
				{
					text:'Номер',
					width:'80',
					dataIndex:'Номер',
					flex:1,
				},
				{
					text:'Сценарий',
					width:'1200',
					dataIndex:'Сценарий',
					flex:1,
				},
				{
					text:'Вид контролируемых значений',
					width:'1200',
					dataIndex:'ВидКонтролируемыхЗначений',
					flex:1,
				},
				{
					text:'Использование контролируемых значений',
					width:'1200',
					dataIndex:'ИспользованиеКонтролируемыхЗначений',
					flex:1,
				},
				{
					text:'Вид ограничения оборотов',
					width:'1200',
					dataIndex:'ВидОграниченияОборотов',
					flex:1,
				},
				{
					text:'Контролирующий сценарий',
					width:'1200',
					dataIndex:'КонтролирующийСценарий',
					flex:1,
				},
				{
					text:'Ответственный',
					width:'1200',
					dataIndex:'Ответственный',
					flex:1,
				},
				{
					text:'Состояние',
					width:'100',
					dataIndex:'Состояние',
					flex:1,
				},
				{
					text:'Дата начала контроля оборотов ',
					width:'80',
					dataIndex:'ДатаНачалаКонтролирующегоСценария',
					flex:1,
				},
				{
					text:'Дата конца контроля оборотов ',
					width:'80',
					dataIndex:'ДатаКонцаКонтролирующегоСценария',
					flex:1,
				},
				{
					text:'Вид отклонения контролируемых значений',
					width:'1200',
					dataIndex:'ВидОтклоненияКонтролируемыхЗначений',
					flex:1,
				},
				{
					text:'Отклонение',
					width:'80',
					dataIndex:'Отклонение',
					flex:1,
				},
				{
					text:'Комментарий',
					width:'1200',
					dataIndex:'Комментарий',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/КонтролируемыеЗначенияПоБюджетам/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Картинка',
					},
					{
						name:'Дата',
					},
					{
						name:'Номер',
					},
					{
						name:'Сценарий',
					},
					{
						name:'ВидКонтролируемыхЗначений',
					},
					{
						name:'ИспользованиеКонтролируемыхЗначений',
					},
					{
						name:'ВидОграниченияОборотов',
					},
					{
						name:'КонтролирующийСценарий',
					},
					{
						name:'Ответственный',
					},
					{
						name:'Состояние',
					},
					{
						name:'ДатаНачалаКонтролирующегоСценария',
					},
					{
						name:'ДатаКонцаКонтролирующегоСценария',
					},
					{
						name:'ВидОтклоненияКонтролируемыхЗначений',
					},
					{
						name:'Отклонение',
					},
					{
						name:'Комментарий',
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
						var грид = Ext.getCmp('ДокументСписок');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:780px;height:25px;',
			dock: 'top',
			items:
			[
				{
					xtype: 'splitbutton',
					text:'',
					menu: [
				{
					text:'Движения документа по регистрам',
				},
				{
					text:'',
				},
				'-',
					]
				},
			]
		},
	]
});