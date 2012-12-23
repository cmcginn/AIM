<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs">
  <xsl:output method="xml" encoding="UTF-8" indent="yes"/>
  <xsl:template match="/">
    <xsl:variable name="var1_instance_allclients" select="."/>
    <AllClientsContact xmlns="http://www.aimscrm.com/schema/2011/common/contact">
      <xsl:for-each select="$var1_instance_allclients/*[local-name()='contact' and namespace-uri()='']">
        <xsl:variable name="var2_contact" select="."/>
        <FirstName>
          <xsl:value-of select="string($var2_contact/firstname)"/>
        </FirstName>
        <LastName>
          <xsl:value-of select="string($var2_contact/lastname)"/>
        </LastName>
        <City>
          <xsl:value-of select="string($var2_contact/city)"/>
        </City>
        <State>
          <xsl:value-of select="string($var2_contact/state)"/>
        </State>
        <Zip>
          <xsl:value-of select="string($var2_contact/postalcode)"/>
        </Zip>
        <Email>
          <xsl:value-of select="string($var2_contact/email)"/>
        </Email>
        <Categories>
          <xsl:for-each select="$var2_contact/category">
            <xsl:variable name="category" select="."/>
          <Category>
            <Id>
              <xsl:value-of select="string($category/id)"/>
            </Id>
            <Name>
              <xsl:value-of select="string($category/name)"/>
            </Name>
          </Category>
          </xsl:for-each>
        </Categories>
        <Flags>
          <xsl:for-each select="$var2_contact/*[local-name()='flags' and namespace-uri()='']/*[local-name()='flag' and namespace-uri()='']">
            <xsl:variable name="flag" select="."/>
            <Flag>
              <Id>
                <xsl:value-of select="string($flag/id)"/>
              </Id>
              <Name>
                <xsl:value-of select="string($flag/name)"/>
              </Name>
            </Flag>
          </xsl:for-each>
        </Flags>
        <Address/>
      </xsl:for-each>
    </AllClientsContact>
  </xsl:template>
</xsl:stylesheet>