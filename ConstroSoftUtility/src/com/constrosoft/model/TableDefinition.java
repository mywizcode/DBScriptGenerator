package com.constrosoft.model;

import java.util.LinkedHashSet;

public class TableDefinition {

	private String name;
	private LinkedHashSet<ColumnDefinition> columns = new LinkedHashSet<ColumnDefinition>();
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public LinkedHashSet<ColumnDefinition> getColumns() {
		return columns;
	}
	public void setColumns(LinkedHashSet<ColumnDefinition> columns) {
		this.columns = columns;
	}
}
