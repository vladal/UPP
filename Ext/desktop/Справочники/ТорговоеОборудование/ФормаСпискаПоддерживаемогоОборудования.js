﻿Ext.require(['Данные.Справочники.ТорговоеОборудование'], function () 
{
	Ext.define('Справочники.ТорговоеОборудование.ФормаСпискаПоддерживаемогоОборудования',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:400px;height:300px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	resizable: false,
	title: 'Поддерживаемое торговое оборудование',
	
	layout: {type: "fit",align: "stretch"},
	items:
	[{
		xtype: 'form',
		items:
		[
		],
	}],
	dockedItems:
	[
	]
	});
});