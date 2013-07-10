﻿Ext.define('Отчеты.РегламентированныйОтчет4ФСС.ФормаВыбораСертификата',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:657px;height:255px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Выберите сертификат',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'Сертификаты',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:641px;height:214px;',
			height: 214,width: 641,
			columns:
			[
				{
					text:'Представление',
					width:'1200',
					dataIndex:'Наименование',
					flex:1,
				},
				{
					text:'Начало действия',
					width:'1200',
					dataIndex:'ДействителенС',
					flex:1,
				},
				{
					text:'Конец действия',
					width:'1200',
					dataIndex:'ДействителенПо',
					flex:1,
				},
				{
					text:'Отпечаток',
					width:'2400',
					dataIndex:'Отпечаток',
					flex:1,
				},
				{
					text:'Поставщик',
					width:'1200',
					dataIndex:'Поставщик',
					flex:1,
				},
				{
					text:'Серийный номер',
					width:'1200',
					dataIndex:'СерийныйНомер',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РегламентированныйОтчет4ФСС/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Наименование',
					},
					{
						name:'ДействителенС',
					},
					{
						name:'ДействителенПо',
					},
					{
						name:'Отпечаток',
					},
					{
						name:'Поставщик',
					},
					{
						name:'СерийныйНомер',
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
						var грид = Ext.getCmp('Сертификаты');
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
			style: 'position:absolute;left:0px;top:0px;width:657px;height:25px;',
			dock: 'top',
			items:
			[
				{
					text:'Выбрать',
				},
				'-',
				{
					text:'Открыть',
				},
			]
		},
	]
});