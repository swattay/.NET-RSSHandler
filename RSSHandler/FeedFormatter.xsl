<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" />
  <xsl:param name="mybreak"><![CDATA[<br/>]]></xsl:param>
  <xsl:template match="/">
    <xsl:for-each select="rss/channel/item">
      <p>
        <a href="{link}" target="_blank">
          <strong>
            <xsl:value-of select="title" disable-output-escaping="yes" />
          </strong>
        </a>
        <xsl:value-of select="$mybreak" disable-output-escaping="yes"/>
        <xsl:value-of disable-output-escaping="yes" select="description" />
      </p>
      <hr />
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>

