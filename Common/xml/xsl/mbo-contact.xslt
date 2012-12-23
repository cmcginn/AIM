﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ns0="http://clients.mindbodyonline.com/API/0_4" xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="ns0 xs">
  <xsl:output method="xml" encoding="UTF-8" indent="yes"/>
  <xsl:template match="/ns0:Row">
    <xsl:variable name="var1_instance_mbo" select="."/>
    <AllClientsContact xmlns="http://www.aimscrm.com/schema/2011/common/contact">      
        <xsl:variable name="var2_Row" select="."/>
        <FirstName>
          <xsl:value-of select="string($var2_Row/ns0:FirstName)"/>
        </FirstName>
        <LastName>
          <xsl:value-of select="string($var2_Row/ns0:LastName)"/>
        </LastName>
        <City>
          <xsl:value-of select="string($var2_Row/ns0:City)"/>
        </City>
        <State>
          <xsl:value-of select="string($var2_Row/ns0:State)"/>
        </State>
        <Zip>
          <xsl:value-of select="string($var2_Row/ns0:PostalCode)"/>
        </Zip>
        <Email>
          <xsl:value-of select="string($var2_Row/ns0:EmailName)"/>
        </Email>
        <Phone>
          <xsl:value-of select="string($var2_Row/ns0:HomePhone)"/>
        </Phone>
      <Custom>
        <Birthday>
          <xsl:value-of select="string($var2_Row/ns0:Birthdate)"/>
        </Birthday>
      </Custom>
    </AllClientsContact>
  </xsl:template>
</xsl:stylesheet>