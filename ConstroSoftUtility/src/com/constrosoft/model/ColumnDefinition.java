package com.constrosoft.model;

public class ColumnDefinition {

	private String name;
	private String dataType;
	private boolean isNullable;
	private String defaultVal;
	private boolean isPK;
	private boolean isFK;
	private boolean isUnique;
	private String constraintName;
	private String constraintTable;
	private String constraintId;
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getDataType() {
		return dataType;
	}
	public void setDataType(String dataType) {
		this.dataType = dataType;
	}
	public boolean isNullable() {
		return isNullable;
	}
	public void setNullable(boolean isNullable) {
		this.isNullable = isNullable;
	}
	public String getDefaultVal() {
		return defaultVal;
	}
	public void setDefaultVal(String defaultVal) {
		this.defaultVal = defaultVal;
	}
	public boolean isPK() {
		return isPK;
	}
	public void setPK(boolean isPK) {
		this.isPK = isPK;
	}
	public boolean isFK() {
		return isFK;
	}
	public void setFK(boolean isFK) {
		this.isFK = isFK;
	}
	public String getConstraintName() {
		return constraintName;
	}
	public void setConstraintName(String constraintName) {
		this.constraintName = constraintName;
	}
	public String getConstraintTable() {
		return constraintTable;
	}
	public void setConstraintTable(String constraintTable) {
		this.constraintTable = constraintTable;
	}
	public String getConstraintId() {
		return constraintId;
	}
	public void setConstraintId(String constraintId) {
		this.constraintId = constraintId;
	}
	public boolean isUnique() {
		return isUnique;
	}
	public void setUnique(boolean isUnique) {
		this.isUnique = isUnique;
	}
}
